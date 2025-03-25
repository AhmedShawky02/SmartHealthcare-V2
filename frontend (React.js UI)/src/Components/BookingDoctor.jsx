import { useEffect, useState } from "react";
import { Form, useActionData, useNavigate, useNavigation, useParams, useRouteLoaderData } from "react-router-dom";
import classes from '../Components/BookingDoctor.module.css'

export default function BookingDoctor({ type }) {
    const [isRedirecting, setIsRedirecting] = useState(false);
    const { doctorId, nurseId } = useParams();
    const data = useRouteLoaderData("Profile");

    const navigate = useNavigate();
    const response = useActionData();
    const navigation = useNavigation();

    const isSubmitting = navigation.state === "submitting";

    const actionUrl = type === "doctor" ? `/Booking/doctors/${doctorId}` : `/Booking/nurses/${nurseId}`;


    const design = response?.message?.includes("successfully") ? classes.successData : classes.errorData;

    useEffect(() => {
        if (response?.message?.includes("successfully")) {
            setIsRedirecting(true);
            const timer = setTimeout(() => {
                navigate("/");
            }, 1500);

            return () => clearTimeout(timer);
        }
    }, [response, navigate]);

    return (
        <>
            <section className={classes.section}>
                <div className={classes.container}>
                    <div className={classes.locationData}>
                        <div className={classes.addressData}>
                            <h2>Location</h2>
                            <ul className={classes.list}>
                                <li>📍 123 Medical St, City</li>
                                <li>📞 +123 456 7890</li>
                            </ul>
                        </div>
                        <div className={classes.followData}>
                            <h2>Follow Us</h2>
                            <div className={classes.socialIcons}>
                                <a href="https://www.facebook.com" target="_blank" rel="noopener noreferrer">
                                    <i className="fab fa-facebook"></i>
                                </a>
                                <a href="https://www.instagram.com" target="_blank" rel="noopener noreferrer">
                                    <i className="fab fa-instagram"></i>
                                </a>
                                <a href="https://www.twitter.com" target="_blank" rel="noopener noreferrer">
                                    <i className="fab fa-twitter"></i>
                                </a>
                            </div>
                            <p>© Privacy Policy {new Date().getFullYear()}</p>
                        </div>
                    </div>
                    <div className={classes.FormData}>
                        <h2>{type === "doctor" ? "Doctor Booking" : "Nurse Booking"}</h2>
                        <Form method="post"  action={actionUrl}>
                            <label className={classes.label}>
                                Your Name: <br />
                                <input className={classes.input} type="text" name="username" value={data.name} readOnly/>
                            </label>
                            <br />
                            <label className={classes.label}>
                                Select Date:<br />
                                <input className={classes.input} type="date" name="date" required />
                            </label>
                            <br />
                            <button className={classes.button} disabled={isSubmitting || isRedirecting}>
                                {isSubmitting ? "Booking..." : isRedirecting ? "Done Booking" : "Book Now"}
                            </button>
                        </Form>
                    </div>
                </div>
                {response && <p className={design}>{response.message}</p>}
            </section>
        </>
    );
}