import { useNavigate, useRouteLoaderData } from 'react-router-dom';
import classes from './DoctorItem.module.css';
import { useState } from 'react';

export default function DoctorItem({ data }) {
    const [showMessage, setShowMessage] = useState(false);

    const token = useRouteLoaderData("root"); // افتراض أنك تجلب التوكين من الراوتر
    const navigate = useNavigate();

    function handelBooking(event) {
        event.preventDefault();

        if (!token) {
            setShowMessage(true)

            setTimeout(() => {
                setShowMessage(false);
                navigate("/Account/login");
            }, 2000);

            return
        }

        navigate(`/Booking/doctors/${data.doctorId}`);
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
                        <div className={classes.rating}>
                            {Array.from({ length: 5 }, (_, i) => (
                                <i
                                    key={i}
                                    className={i < Math.round(data.rating) ? "fas fa-star" : "far fa-star"}>
                                </i>
                            ))}
                        </div>
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
                            <strong>Available Time:</strong> <span>{data.availableTime}</span>
                        </div>
                        <div className={classes.infoItem}>
                            <strong>Center:</strong> <span>{data.centerName}</span>
                        </div>
                        <div className={classes.infoItem}>
                            <strong>Department:</strong> <span>{data.departmentName}</span>
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
