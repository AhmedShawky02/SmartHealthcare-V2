import { useLoaderData } from "react-router-dom";
import DoctorList from "./DoctorList";

export default function Doctors() {
    const data = useLoaderData();
    return (
        <>
            <DoctorList data={data} />
        </>
    );
}



