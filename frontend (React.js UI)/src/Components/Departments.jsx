import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination, Autoplay } from "swiper/modules";
import "swiper/css";
import "swiper/css/navigation";
import "swiper/css/pagination";
import classes from "./Departments.module.css";
import { Link } from "react-router-dom";

export default function Departments({ data }) {

    if (!data || data.length === 0) {
        return (
            <section className={classes.section}>
                <h2 className={classes.title}>Healthcare Specialties</h2>
                <h3>Loading...</h3>
                <div className={classes.loader}></div>
            </section>
        );
    }

    return (
        <section className={classes.section}>
            <h2 className={classes.title}>Healthcare Specialties</h2>
            <Swiper
                modules={[Navigation, Pagination, Autoplay]}
                spaceBetween={30}
                slidesPerView={window.innerWidth >= 2000 ? 4 : 3} // إذا كانت الشاشة أكبر من 2000px يعرض 4، وإلا يعرض 3
                navigation
                pagination={{ clickable: true }}
                autoplay={{ delay: 3000, disableOnInteraction: false }}
                loop={true}
                breakpoints={{
                    1800: { slidesPerView: 4 },
                    1024: { slidesPerView: 3 }, 
                    768: { slidesPerView: 2 },  
                    0: { slidesPerView: 1 } ,
                }}
                className={classes.swiper}
            >
                {data.map((dep) => {
                    return (
                        <SwiperSlide key={dep.departmentId} className={classes.card}>
                            <Link to={`${dep.departmentId}/doctors`} className={classes.cardContent}>
                                <div className={classes.image}>
                                    <img src={dep.picture} alt={dep.name} />
                                </div>
                                <div className={classes.info}>
                                    <h2>{dep.name}</h2>
                                </div>
                            </Link>
                        </SwiperSlide>
                    );
                })}
            </Swiper>
        </section>
    );
}
