import { NavLink } from 'react-router-dom';
import classes from "../Components/ProfileNavBar.module.css"
import { FaUser, FaLock } from "react-icons/fa";

function ProfileNavBar() {

    return (
        <header className={classes.header} >
            <nav className={classes.navbar}>
                <ul className={classes.links}>
                    <li className={classes.li}>
                        <NavLink to={'/Account/Profile'}
                            className={({ isActive }) => isActive ? classes.active : undefined} end
                        >
                            <FaUser style={{ marginRight: "8px" }} /> My Page
                        </NavLink>
                    </li>
                    <li className={classes.li}>
                        <NavLink to={'/Account/Profile/ChangePassword'}
                            className={({ isActive }) => isActive ? classes.active : undefined} end
                        >
                            <FaLock style={{ marginRight: "8px" }} /> Change Password
                        </NavLink>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default ProfileNavBar;