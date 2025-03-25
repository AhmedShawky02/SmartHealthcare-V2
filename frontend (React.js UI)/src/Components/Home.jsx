import Departments from "./Departments";
import Diseases from "./Diseases";
import Footer from "./Footer";
import HomePage from "./MainPage";
import WelcomeSectionPage from "./WelcomeSectionPage";
import { useLoaderData } from "react-router-dom";


export default function Home() {
    const { departments, diseases } = useLoaderData()

    return(
        <>
            <HomePage />
            <WelcomeSectionPage />
            <Departments data={departments}/>
            <Diseases data={diseases} />
            <Footer />
        </>
    );
}