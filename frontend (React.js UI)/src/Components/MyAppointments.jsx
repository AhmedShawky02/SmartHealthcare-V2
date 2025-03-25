import { useFetcher, useLoaderData } from "react-router-dom";
import classes from '../Components/MyAppointments.module.css';
import { useEffect, useState } from "react";

export default function MyAppointments() {
    const data = useLoaderData();
    const [step, SetStep] = useState("delete");
    const [response, setResponse] = useState(null);
    const [selectedId, setSelectedId] = useState(null);
    const [responseMessage, setResponseMessage] = useState("");
    const [isSubmitting, setIsSubmitting] = useState(false);

    const allBookings = [
        ...(Array.isArray(data?.doctorBookings) ? data.doctorBookings : []),
        ...(Array.isArray(data?.nurseBookings) ? data.nurseBookings : [])
    ];

    function handleDelete(id, type) {
        setSelectedId({ id, type }); // حفظ الـ id مع نوع الحجز
        SetStep("Confirm");
    }

    const BookingAction = useFetcher();

    function confirmDelete(event) {
        event.preventDefault();
        setIsSubmitting(true);

        const actionPath = selectedId.type === "doctor" ? "DeleteDoctorBooking" : "DeleteNurseBooking";

        const formdata = new FormData();
        formdata.append("id", selectedId.id);
        BookingAction.submit(formdata, { method: "post", action: actionPath });
    }

    useEffect(() => {
        if (BookingAction.state === "idle" && BookingAction.data) {
            if (BookingAction.data.message.includes("Booking deleted successfully")) {
                setResponse(classes.successData);
            } else {
                setResponse(classes.errorData);
            }

            setResponseMessage(BookingAction.data.message);

            if (BookingAction.data.message.includes("Booking deleted successfully")) {
                const timer = setTimeout(() => {
                    SetStep("delete");
                    setSelectedId(null);
                    setResponseMessage("");
                    setIsSubmitting(false);
                }, 1000);

                return () => clearTimeout(timer);
            } else {
                setIsSubmitting(false);
            }
        }
    }, [BookingAction.state, BookingAction.data]);

    function cancelDelete() {
        SetStep("delete");
        setSelectedId(null);
        setIsSubmitting(false);
    }

    return (
        <>
            <section className={classes.section}>
                <div className={classes.container}>
                    <h2 className={classes.title}>My Appointments</h2>

                    {allBookings.length > 0 ? (
                        <table className={classes.table}>
                            <thead className={classes.thead}>
                                <tr className={classes.tr}>
                                    <th className={classes.th}>No.</th>
                                    <th className={classes.th}>Name</th>
                                    <th className={classes.th}>Type</th>
                                    <th className={classes.th}>Date</th>
                                    <th className={classes.th}></th>
                                </tr>
                            </thead>

                            <tbody className={classes.tbody}>
                                {allBookings.map((row, index) => (
                                    <tr key={row.bookingDoctorId || row.bookingNurseId}>
                                        <td className={classes.td}>{index + 1}</td>
                                        <td className={classes.td}>{row.doctorName || row.nurseName}</td>
                                        <td className={classes.td}>{row.doctorName ? "Doctor" : "Nurse"}</td>
                                        <td className={classes.td}>
                                            {new Intl.DateTimeFormat('en-GB', {
                                                year: 'numeric',
                                                month: 'long',
                                                day: 'numeric',
                                                hour: '2-digit',
                                                minute: '2-digit',
                                                second: '2-digit',
                                                hour12: true
                                            }).format(new Date(row.date))}
                                        </td>
                                        <td className={classes.td}>
                                            <button
                                                className={classes.deleteBtn}
                                                onClick={() => handleDelete(row.bookingDoctorId || row.bookingNurseId, row.doctorName ? "doctor" : "nurse")}
                                                >
                                                Cancel
                                            </button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    ) : (
                        <p className={classes.noData}>No appointments found.</p>
                    )}
                </div>

                {step === "Confirm" && (
                    <div className={classes.ConfirmDelete}>
                        <div className={classes.ConfirmDeleteContainer}>
                            <h3>Are you sure you want to cancel this booking?</h3>
                            <form onSubmit={confirmDelete}>
                                <button type="submit" disabled={isSubmitting}>Yes</button>
                                <button type="button" onClick={cancelDelete} disabled={isSubmitting}>No</button>
                            </form>
                            {responseMessage && <p className={response}>{responseMessage}</p>}
                        </div>
                    </div>
                )}
            </section>
        </>
    );
}
