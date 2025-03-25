import { Link, useNavigate } from 'react-router-dom';
import classes from './DoctorList.module.css';
import { useState } from 'react';
import { getAuthToken } from '../loader/auth';


export default function NursesList({ data }) {
    const [showMessage, setShowMessage] = useState(false);
    const navigate = useNavigate();

    const nurses = Array.isArray(data) && data !== null && data !== undefined ? data : [];


    function handleBookingClick(nurseId, event) {
        event.preventDefault();

        const token = getAuthToken();

        if (!token) {
            setShowMessage(true)

            setTimeout(() => {
                setShowMessage(false);
                navigate("/Account/login");
            }, 2000);

            return
        }

        navigate(`/Booking/nurses/${nurseId}`);
    }


    return (
        <section className={classes.section}>
            <div className={classes.container}>
                {nurses.length === 0 ? (
                    <p className={classes.noDoctors}>No Nurses available at the moment. Nurses will be added soon!</p>
                ) : (
                    nurses.map((nurse) => {
                        return (
                            <div className={classes.box} key={nurse.nurseId}>
                                <div className={classes.image}>
                                    <img
                                        src={nurse.profilePicture}
                                        alt={nurse.name}
                                        // onError={(e) => e.target.src = "fallback-image.jpg"}
                                    />
                                </div>
                                <div className={classes.name_job}>{nurse.name}</div>
                                <p>{nurse.info}</p>
                                <div className={classes.btns}>
                                    <Link to={`/nurses/${nurse.nurseId}`}>
                                        Read More
                                    </Link>
                                    <button className={classes.bookingButton} onClick={(event) => handleBookingClick(nurse.nurseId, event)}>
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
