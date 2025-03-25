import { Form, useActionData, useLoaderData, useNavigate, useNavigation, useRouteLoaderData } from 'react-router-dom';
import classes from '../Components/Profile.module.css';
import { useEffect, useState } from 'react';

export default function Profile() {

    const [showSave, setShowSave] = useState(false);
    const navigation = useNavigation();
    const Data = useLoaderData();

    const response = useActionData();

    const design = response?.message?.includes("successfully") ? classes.successData : classes.errorData;


    const [formValues, setFormValues] = useState({
        name: Data.name,
        email: Data.email,
        age: Data.age
    });
    const isSubmitting = navigation.state === "submitting";

    function handelChange(event) {
        const { name, value } = event.target;

        setFormValues((prevValues) => {
            const newValues = {
                ...prevValues,
                [name]: name === "age" ? Number(value) : value
            }

            const hasChanged =
                newValues.name !== Data.name ||
                newValues.email !== Data.email ||
                newValues.age !== Data.age;

            setShowSave(hasChanged);

            return newValues;
        });
    }

    const navigate = useNavigate();

    useEffect(() => {
        if (response?.message?.includes("successfully")) {

            const timer = setTimeout(() => {
                navigate("/Account/Profile");
            }, 1500);

            return () => clearTimeout(timer);
        }
    }, [response, navigate]);

    return (
        <>
            <section className={classes.section}>
                <div className={classes.container}>
                    <h2>Profile management</h2>
                    <Form method="post" action='.'>
                        <label className={classes.label}>
                            Name: <br />
                            <input
                                className={classes.input}
                                onChange={handelChange}
                                type="text"
                                name="name"
                                value={formValues.name}
                                required
                            />
                        </label>

                        <label className={classes.label}>
                            Email: <br />
                            <input
                                className={classes.input}
                                onChange={handelChange}
                                type="email"
                                name="email"
                                value={formValues.email}
                                required
                            />
                        </label>

                        <label className={classes.label}>
                            Age: <br />
                            <input
                                className={classes.input}
                                onChange={handelChange}
                                type="number"
                                name="age"
                                min="0"
                                max="150"
                                value={formValues.age}
                                required
                            />
                        </label>
                        {showSave &&
                            <button className={classes.button} disabled={isSubmitting}>
                                {isSubmitting ? "Saving..." : "Save"}
                            </button>
                        }
                    </Form>
                </div>
                {response && <p className={design}>{response.message}</p>}
            </section>
        </>
    );
}