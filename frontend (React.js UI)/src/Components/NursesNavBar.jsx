import { NavLink } from 'react-router-dom';
import classes from "../Components/DoctorsNavBar.module.css"

function NursesNavBar() {
    return (
        <header className={classes.header} >
            <nav className={classes.navbar}>
                <ul className={classes.links}>
                    <li>
                        <NavLink to={'/nurses'}
                            className={({ isActive }) => isActive ? classes.active : undefined} end
                        > All Nurses </NavLink>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default NursesNavBar;