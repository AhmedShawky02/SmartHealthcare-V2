import { useNavigate } from 'react-router-dom';
import classes from './DoctorItem.module.css';
import { useState } from 'react';
import { getAuthToken } from '../loader/auth';

export default function NurseItem({ data }) {
    const [showMessage, setShowMessage] = useState(false);
    const navigate = useNavigate();

    function handelBooking(event) {
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

        navigate(`/Booking/nurses/${data.nurseId}`);

    }

    return (
        <section className={classes.section} >
            <div className={classes.container}>
                <div className={classes.box} key={data.doctorId}>
                    <div className={classes.infoData}>
                        <div className={classes.image}>
                            <img
                                src={data.profilePicture}
                                alt={data.name}
                                onError={(e) => e.target.src = "fallback-image.jpg"}
                            />
                        </div>
                        <div className={classes.name_job}>{data.name}</div>
                        <div className={classes.btns}>
                            <button onClick={handelBooking} className={classes.bookingButton}>
                                Booking
                            </button>
                        </div>
                    </div>
                    <div className={classes.moreInfo}>
                        <div className={classes.infoItemExperienced}>
                            <span>{data.info}</span>
                        </div>
                        <div className={classes.infoItem}>
                            <strong>Age:</strong> <span>{data.age}</span>
                        </div>
                        <div className={classes.infoItem}>
                            <strong>Center:</strong> <span>{data.centerName}</span>
                        </div>
                    </div>

                </div>
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
