import classes from "../Components/LoginBage.module.css"
import { Form, Link, useActionData, useNavigate, useNavigation } from "react-router-dom";
import { useEffect, useState } from "react";

export default function LoginBage() {
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
                        <h2>Login</h2>
                        <Form method="post">

                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Email: <br />
                                <input className={classes.input} type="email" name="email" required />
                            </label>

                            <label className={`${classes.Datainput} ${classes.label}`}>
                                Password: <br />
                                <input className={classes.input} type="password" name="password" required />
                            </label>

                            <button className={classes.button} disabled={isSubmitting || isRedirecting}>
                                {isSubmitting ? "Login..." : isRedirecting ? "Login successful!" : "Login"}
                            </button>

                            <div className={classes.links}>
                                <Link to="/Account/forgotPassword" className={classes.ForgotPassword}>Forgot Password</Link>
                                <Link to="/Account/signUp" className={classes.SignUp}>signUp</Link>
                            </div>
                        </Form>
                    </div>
                </div>
                {response && <p className={design}>{response.message}</p>}
            </section >
        </>
    );
}