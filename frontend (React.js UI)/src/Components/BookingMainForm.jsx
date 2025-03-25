import { useEffect, useState } from "react";
import { useLoaderData, useNavigate } from "react-router-dom";
import classes from "../Components/BookingMainForm.module.css";

export default function BookingMainForm() {
    const data = useLoaderData()
    const [selectedSpecialty, setSelectedSpecialty] = useState("");
    const [searchTerm, setSearchTerm] = useState("");
    const navigate = useNavigate();
    const [showError, setShowError] = useState(false);

    let departments = Array.isArray(data) && data !== null && data !== undefined ? data : [];

    function handleSearch() {
        if (!selectedSpecialty) {
            setShowError(true);
            return;
        }

        if (searchTerm === "") {
            navigate(`/${selectedSpecialty}/doctors`);
        }
        else {
            navigate(`/${selectedSpecialty}/doctors?search=${searchTerm}`);
        }

    }

    return (
        <>

            <section className={classes.section}>
                <h2 className={classes.title}>Book an Appointment</h2>

                <label className={classes.label}>Select Specialty:</label>
                <select className={classes.select} onChange={(e) => setSelectedSpecialty(e.target.value)} value={selectedSpecialty}>
                    <option value="">Select Specialty</option>
                    {departments.length === 0 ? (
                        <option disabled>No sections available</option>
                    ) : (
                        departments.map((spec) => (
                            <option key={spec.departmentId} value={spec.departmentId}>
                                {spec.name}
                            </option>
                        ))
                    )}
                </select>

                <label className={classes.label}>Search Doctor (optional):</label>
                <input
                    className={classes.input}
                    type="text"
                    placeholder="Enter doctor name..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />

                <button className={classes.button} onClick={handleSearch}>Search</button>

                {showError && (
                    <div className={classes.errorModal}>
                        <div className={classes.errorContent}>
                            <p>Please select a specialty first!</p>
                            <button onClick={() => setShowError(false)}>Cancel</button>
                        </div>
                    </div>
                )}


            </section>
        </>
    );
}
