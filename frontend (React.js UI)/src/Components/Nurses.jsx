import { useLoaderData } from "react-router-dom";
import NursesList from "./NursesList";

export default function Nurses() {
    const data = useLoaderData();
    return (
        <>
            <NursesList data={data} />
        </>
    );
}