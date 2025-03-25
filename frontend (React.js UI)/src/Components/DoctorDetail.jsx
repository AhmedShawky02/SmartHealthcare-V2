import { useLoaderData } from "react-router-dom";
import DoctorItem from "./DoctorItem";
import Reviews from "./Reviews";

export default function DoctorDetail() {
    const { doctorData, reviewsData } = useLoaderData();
    return (
        <>
            <DoctorItem data={doctorData} />
            <Reviews data={reviewsData}/>
        </>
    );
}