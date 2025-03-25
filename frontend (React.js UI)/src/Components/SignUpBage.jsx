import { Form, Link, useActionData, useNavigate, useNavigation } from "react-router-dom";
import classes from '../Components/SignUpBage.module.css'
import DoctorsSignUp from '../assets/DoctorsSignUp.jpg';
import { useEffect, useState } from "react";

export default function SignUpBage() {
    const [isRedirecting, setIsRedirecting] = useState(false);
    const navigate = useNavigate();
    const response = useActionData();
    const navigation = useNavigation();

    const isSubmitting = navigation.state === "submitting";

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
                <div className={classes.content}>
                    <div className={classes.form}>
                        <h2>Sign Up</h2>
                        <Form method="post"> 
                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Name: <br />
                                <input className={classes.input} type="text" name="name" required />
                            </label>

                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Email: <br />
                                <input className={classes.input} type="email" name="email" required />
                            </label>

                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Password: <br />
                                <input className={classes.input} type="password" name="password" required />
                            </label>

                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Age: <br />
                                <input className={classes.input} type="number" name="age" min="0" required />
                            </label>

                            <label className={classes.genderLabel}>
                                Gender:
                                <label className={classes.genderLabel}>
                                    <input className={classes.input} type="radio" name="gender" value="0" required /> Male
                                </label>
                                <label className={classes.genderLabel}>
                                    <input className={classes.input} type="radio" name="gender" value="1" required /> Female
                                </label>
                            </label>

                            <button className={classes.button} disabled={isSubmitting || isRedirecting}>
                                {isSubmitting ? "Creating account..." : isRedirecting ? "Registration successful!" : "Sign up now"}
                            </button>

                            <div className={classes.links}>
                                <Link to="/Account/login" className={classes.SignUp}>Login</Link>
                            </div>
                        </Form>
                    </div>
                    <div className={classes.image}>
                        <img className={classes.photo} src={DoctorsSignUp} alt={DoctorsSignUp} />
                    </div>
                </div>
                {response && <p className={design}>{response.message}</p>}
            </section >
        </>
    );
}