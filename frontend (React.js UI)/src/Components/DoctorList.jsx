import { Link, useNavigate, useSearchParams } from 'react-router-dom';
import classes from './DoctorList.module.css';
import { getAuthToken } from '../loader/auth';
import { useState } from 'react';


export default function DoctorList({ data }) {
    const [showMessage, setShowMessage] = useState(false);

    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const searchQuery = searchParams.get("search")?.toLowerCase() || "";

    let doctors = Array.isArray(data) && data !== null && data !== undefined ? data : [];

    if (searchQuery) {
        doctors = doctors.filter(doctor =>
            doctor.name.toLowerCase().includes(searchQuery)
        );
    }

    function handleBookingClick(doctorId, event) {
        event.preventDefault();

        const token = getAuthToken();

        if (!token) {
            setShowMessage(true)

            const timer = setTimeout(() => {
                setShowMessage(false);
                navigate("/Account/login");
            }, 2000);

            return
        }

        navigate(`/Booking/doctors/${doctorId}`);
    }

    return (
        <section className={classes.section}>
            <div className={classes.container}>
                {doctors.length === 0 ? (
                    <p className={classes.noDoctors}>No doctors available at the moment. doctors will be added soon!</p>
                ) : (
                    doctors.map((doctor) => {
                        return (
                            <div className={classes.box} key={doctor.doctorId}>
                                <div className={classes.image}>
                                    <img
                                        src={doctor.profilePicture}
                                        alt={doctor.name}
                                    />
                                </div>
                                <div className={classes.name_job}>{doctor.name}</div>
                                <div className={classes.rating}>
                                    {Array.from({ length: 5 }, (_, i) => (
                                        <i
                                            key={i}
                                            className={i < Math.round(doctor.rating) ? "fas fa-star" : "far fa-star"}>
                                        </i>
                                    ))}
                                </div>
                                <p>{doctor.info}</p>
                                <div className={classes.btns}>
                                    <Link to={`/doctors/${doctor.doctorId}`}>
                                        Read More
                                    </Link>
                                    <button
                                        onClick={(event) => handleBookingClick(doctor.doctorId, event)}
                                        className={classes.bookingButton}
                                    >
                                        Booking
                                    </button>
                                </div>
                            </div>
                        );
                    })
                )}
            </div>
            {showMessage &&
                <div className={classes.containerMessage}>
                    <div className={classes.showMessage}>
                        <p>You must login first...</p>
                        <div className={classes.progressBar}>
                            <div className={classes.progress}></div>
                        </div>
                    </div>
                </div>
            }
        </section>
    );
}
