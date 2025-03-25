import React, { useState, useEffect } from "react";
import { Form, Link, NavLink, useRouteLoaderData } from "react-router-dom";
import { FaBars, FaTimes } from "react-icons/fa";
import { FaUser, FaCalendarCheck } from "react-icons/fa"; // استيراد الأيقونات
import { FaUserCircle, FaCaretDown } from "react-icons/fa"; // استيراد الأيقونات
import classes from "../Components/Navbar.module.css";
import logo from "../assets/logo.png";

export default function Navbar() {
    const [menuOpen, setMenuOpen] = useState(false);
    const [isOpen, setIsOpen] = useState(false);
    const token = useRouteLoaderData("root");

    // إغلاق القائمة المنسدلة عند الضغط خارجها
    useEffect(() => {
        const closeDropdown = (e) => {
            if (!e.target.closest(`.${classes.dropdown}`)) {
                setIsOpen(false);
            }
        };
        document.addEventListener("click", closeDropdown);
        return () => document.removeEventListener("click", closeDropdown);
    }, []);

    return (
        <header className={classes.header}>
            <nav className={classes.navbar}>
                <Link to="/" className={classes.logo}>
                    <img src={logo} alt="logo" />
                    <h2>Doctors</h2>
                </Link>

                {/* زر فتح القائمة */}
                <div className={classes.menuButton} onClick={() => setMenuOpen(!menuOpen)}>
                    {menuOpen ? <FaTimes size={30} /> : <FaBars size={30} />}
                </div>

                {/* الخلفية الشفافة عند فتح القائمة */}
                <div
                    className={`${classes.menuOverlay} ${menuOpen ? classes.showOverlay : ""}`}
                    onClick={() => setMenuOpen(false)}
                ></div>

                {/* القائمة الجانبية */}
                <ul className={`${classes.links} ${menuOpen ? classes.showMenu : ""}`}>
                    <li>
                        <NavLink to="/" className={({ isActive }) => (isActive ? classes.active : undefined)} end onClick={() => setMenuOpen(false)}>
                            Home
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to="about-us" className={({ isActive }) => (isActive ? classes.active : undefined)} end onClick={() => setMenuOpen(false)}>
                            About Us
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to="Booking" className={({ isActive }) => (isActive ? classes.active : undefined)} end onClick={() => setMenuOpen(false)}>
                            Booking
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to="doctors" className={({ isActive }) => (isActive ? classes.active : undefined)} end onClick={() => setMenuOpen(false)}>
                            Doctors
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to="nurses" className={({ isActive }) => (isActive ? classes.active : undefined)} end onClick={() => setMenuOpen(false)}>
                            Nurses
                        </NavLink>
                    </li>

                    {/* عرض زر تسجيل الدخول والتسجيل في حالة عدم وجود توكين */}
                    {!token && (
                        <>
                            <li>
                                <Link onClick={() => setMenuOpen(false)} to="/Account/login">
                                    <button className={classes.login}>LOG IN</button>
                                </Link>
                            </li>
                            <li>
                                <Link onClick={() => setMenuOpen(false)} to="/Account/signUp">
                                    <button className={classes.signup}>SIGN UP</button>
                                </Link>
                            </li>
                        </>
                    )}

                    {/* قائمة Profile المنسدلة */}
                    {token && (
                        <li className={`${classes.dropdown} ${isOpen ? classes.open : ""}`}>
                            <button
                                className={classes.menuButtonClick}
                                onClick={(e) => {
                                    e.stopPropagation(); // منع غلق القائمة عند الضغط على الزر
                                    setIsOpen(!isOpen);
                                }}
                            >
                                <FaUserCircle size={30} style={{ marginRight: "8px" }} />
                                <FaCaretDown size={20} />
                            </button>
                            
                            {isOpen && (
                                <div className={classes.dropdownContent}>
                                    <Link onClick={() => { setIsOpen(false) ; setMenuOpen(false)}} to="/Account/Profile" className={classes.dropdownLink}>                                        <FaUser style={{ marginRight: "8px" }} />
                                        View Profile
                                    </Link>
                                    <Link onClick={() => { setIsOpen(false) ; setMenuOpen(false)}} to="/Account/MyAppointments" className={classes.dropdownLink}>
                                        <FaCalendarCheck style={{ marginRight: "8px" }} />
                                        My Appointments
                                    </Link>
                                    <Form method="post" action="/logout">
                                        <button className={classes.logoutButton}>
                                            Logout
                                        </button>
                                    </Form>
                                </div>
                            )}
                        </li>
                    )}
                </ul>
            </nav>
        </header>
    );
}
