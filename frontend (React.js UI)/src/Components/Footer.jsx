import { Link } from "react-router-dom";
import classes from "../Components/Footer.module.css";

export default function Footer() {
    return (
        <footer className={classes.footer}>
            <div className={classes.footerContainer}>

                <div className={classes.footerSection}>
                    <h3 className={classes.title}>Our Services</h3>
                    <ul className={classes.list}>
                        <li><Link to="/doctors" className={classes.link}>👨‍⚕️ Doctors</Link></li>
                        <li><Link to="/nurses" className={classes.link}>👩‍⚕️ Nurses</Link></li>
                        <li><Link to="/about-us" className={classes.link}>ℹ️ About Us</Link></li>
                        <li><Link to="/booking" className={classes.link}>📅 Booking</Link></li>
                    </ul>
                </div>

                <div className={classes.footerSection}>
                    <h3 className={classes.title}>Contact Us</h3>
                    <ul className={classes.list}>
                        <li>📍 123 Medical St, City</li>
                        <li>📞 +123 456 7890</li>
                    </ul>
                </div>

                <div className={classes.footerSection}>
                    <h3 className={classes.title}>Email</h3>
                    <a className={classes.email} href="mailto:contact@medicalcenter.com"> acontact@medicalcenter.com</a>
                </div>

            </div>
        </footer>
    );
}
