import { NavLink } from 'react-router-dom';
import classes from "../Components/DoctorsNavBar.module.css"

function DoctorsNavBar() {
    
    return (
        <header className={classes.header} >
            <nav className={classes.navbar}>
                <ul className={classes.links}>
                    <li>
                        <NavLink to={'/doctors'}
                            className={({ isActive }) => isActive ? classes.active : undefined} end
                        > All Doctors </NavLink>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default DoctorsNavBar;