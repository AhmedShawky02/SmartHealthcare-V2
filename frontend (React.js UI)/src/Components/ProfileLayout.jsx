import { Outlet } from "react-router-dom";
import ProfileNavBar from "./ProfileNavBar";
import classes from '../Components/ProfileLayout.module.css';

export default function ProfileLayout(){
    return(
        <div className={classes.main}>

            <div className={classes.ProfileNavBar}>
                <ProfileNavBar />
            </div>

            <div className={classes.Outlet}>
                <Outlet />
            </div>

        </div>
    );
}