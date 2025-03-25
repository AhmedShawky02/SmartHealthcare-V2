import { Outlet } from "react-router-dom";
import NursesNavBar from "./NursesNavBar";

export default function NursesLayout(){
    return(
        <>
            <NursesNavBar />
            <Outlet />
        </>
    );
}