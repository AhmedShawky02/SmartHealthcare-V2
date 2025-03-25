import { useLoaderData } from "react-router-dom";
import NurseItem from "./NurseItem";

export default function NurseDetail() {
    const { nurseData } = useLoaderData();
    return (
        <>
            <NurseItem data={nurseData} />
        </>
    );
}