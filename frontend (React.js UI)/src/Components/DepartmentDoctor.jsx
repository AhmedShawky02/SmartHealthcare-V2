import { useLoaderData } from "react-router-dom";
import DoctorList from "./DoctorList";

export default function DepartmentDoctor() {

    const data = useLoaderData()
    return (
        <>
            <DoctorList data={data} />
        </>
    );
}