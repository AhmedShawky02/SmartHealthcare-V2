import { Outlet } from "react-router-dom";
import DoctorsNavBar from "./DoctorsNavBar";

export default function DoctorsLayout(){
    return(
        <>
            <DoctorsNavBar />
            <Outlet />
        </>
    );
}