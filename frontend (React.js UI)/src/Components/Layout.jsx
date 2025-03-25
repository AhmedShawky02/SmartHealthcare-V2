import { Outlet, useLoaderData, useSubmit } from "react-router-dom";
import Navbar from "./Navbar";
import ScrollToTop from "../../util/ScrollToTop";
import { useEffect } from "react";
import { getTokenDuration } from "../loader/auth";

export default function Layout() {

    const token = useLoaderData();
    const submit = useSubmit();

    useEffect(() => {

        if (!token) {
            return;
        }

        if (token === 'EXPIRED') {
            submit(null, { action: '/logout', method: 'post' });
            return;
        }

        const tokenDuration = getTokenDuration();

        const timer = setTimeout(() => {
            submit(null, { action: "/logout", method: "post" });
        }, tokenDuration);

    }, [token, submit])

    return (
        <>
            <ScrollToTop />
            <Navbar />
            <main>
                <Outlet />
            </main>
        </>
    );
}
