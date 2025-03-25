import { useFetcher, useLoaderData, useNavigate, useRouteLoaderData } from "react-router-dom";
import classes from '../Components/ChangePassword.module.css';
import { useEffect, useRef, useState } from "react";

export default function ChangePassword() {
    const [step, setStep] = useState("email");
    const [response, setResponse] = useState(null);
    const [storeToken, setStoreToken] = useState("");
    const data = useLoaderData();

    const navigate = useNavigate();

    const emailFetcher = useFetcher();
    const tokenFetcher = useFetcher();
    const changePasswordFetcher = useFetcher();

    useEffect(() => {
        if (emailFetcher.data?.message?.includes("Check your email")) {
            setResponse(classes.successData);
            const timer = setTimeout(() => {
                setStep("token");
            }, 1500);

            return () => clearTimeout(timer);

        }
        setResponse(classes.errorData);

    }, [emailFetcher.data]);

    useEffect(() => {
        if (tokenFetcher.data?.message?.includes("Token is valid")) {
            setResponse(classes.successData);

            const timer = setTimeout(() => {
                setStep("new-password");
            }, 1500);

            setStoreToken(tokenFetcher.data.token)
            return () => clearTimeout(timer);
        }
        setResponse(classes.errorData);

    }, [tokenFetcher.data]);

    useEffect(() => {
        if (changePasswordFetcher.data?.message?.includes("Password updated successfully")) {
            setResponse(classes.successData);

            const timer = setTimeout(() => {
                navigate("/");
            }, 1500);

            return () => clearTimeout(timer);
        }
        setResponse(classes.errorData);

    }, [changePasswordFetcher.data, navigate]);


    const [token, setToken] = useState(["", "", "", "", ""]);

    const inputsRef = [useRef(), useRef(), useRef(), useRef(), useRef()];

    function handleChange(index, e) {
        const value = e.target.value;

        if (/^\d?$/.test(value)) { // يقبل رقم واحد فقط
            const newToken = [...token];
            newToken[index] = value;
            setToken(newToken);

            // الانتقال للخانة التالية تلقائيًا
            if (value && index < 4) {
                inputsRef[index + 1].current.focus();
            }
        }
    }

    function handleBackspace(index, e) {
        if (e.key === "Backspace" && !token[index] && index > 0) {
            inputsRef[index - 1].current.focus();
        }
    }

    function handleSubmit(event) {

        event.preventDefault();

        const formdata = new FormData(event.target)

        formdata.append("token", token)

        changePasswordFetcher.submit(formdata, { method: "post", action: "change-password" });
    }

    return (
        <>
            <section className={classes.section}>
                <div className={classes.container}>
                    {step === "email" ? (
                        <>
                            <h2>Change Password</h2>
                            <emailFetcher.Form method="post" action="send-email">
                                <label className={classes.label}>
                                    Email: <br />
                                    <input
                                        className={classes.input}
                                        placeholder="Enter Your Email"
                                        type="email"
                                        name="email"
                                        value={data.email}
                                        readOnly
                                    />
                                </label>

                                <button type="submit" className={classes.button} disabled={emailFetcher.state === "submitting"}>
                                    {emailFetcher.state === "submitting" ? "Sending..." : "Send"}
                                </button>
                            </emailFetcher.Form>
                        </>
                    ) : step === "token" ? (
                        <>
                            <h2>Verify Your Token</h2>
                            <tokenFetcher.Form method="post" action="verify-token">
                                <div className={classes.tokenContainer}>
                                    {token.map((digit, index) => (
                                        <input
                                            key={index}
                                            type="text"
                                            maxLength="1"
                                            className={classes.tokenInput}
                                            value={digit}
                                            name={`token-${index}`}
                                            onChange={(e) => handleChange(index, e)}
                                            onKeyDown={(e) => handleBackspace(index, e)}
                                            ref={inputsRef[index]}
                                        />
                                    ))}
                                </div>

                                <button type="submit" className={classes.button} disabled={tokenFetcher.state === "submitting"}>
                                    {tokenFetcher.state === "submitting" ? "Verifying..." : "Verify"}
                                </button>
                            </tokenFetcher.Form>
                        </>
                    ) : (
                        <>
                            <h2>Set Your New Password</h2>
                            <form onSubmit={handleSubmit}>
                                <label className={classes.label}>
                                    New Password : <br />
                                    <input
                                        className={classes.input}
                                        type="text"
                                        name="newPassword"
                                        required
                                    />
                                </label>

                                <label className={classes.label}>
                                    Confirm password : <br />
                                    <input
                                        className={classes.input}
                                        type="text"
                                        name="confirmPassword"
                                        required
                                    />
                                </label>

                                <button type="submit" className={classes.button} disabled={changePasswordFetcher.state === "submitting"}>
                                    {changePasswordFetcher.state === "submitting" ? "Changing..." : "Change Password"}
                                </button>
                            </form>
                        </>
                    )}
                </div>
                {step === "email" ? (
                    emailFetcher.data && <p className={response}>{emailFetcher.data.message}</p>
                ) : step === "token" ? (
                    tokenFetcher.data && <p className={response}>{tokenFetcher.data.message}</p>
                ) : (
                    changePasswordFetcher.data && <p className={response}>{changePasswordFetcher.data.message}</p>
                )}

            </section>
        </>
    );
}