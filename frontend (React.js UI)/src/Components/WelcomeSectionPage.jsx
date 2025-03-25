import { useEffect, useRef } from 'react';
import welcomeDoctor from '../assets/WelcomeDoctor.png';
import classes from '../Components/WelcomeSectionPage.module.css';

export default function WelcomeSectionPage() {
    const sectionRef = useRef(null);

    useEffect(() => {
        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    sectionRef.current.querySelector(`.${classes.contentImage}`).classList.add(classes.visible);
                    sectionRef.current.querySelector(`.${classes.contentData}`).classList.add(classes.visible);
                    observer.disconnect();
                }
            },
            { threshold: 0.3 }
        );

        if (sectionRef.current) {
            observer.observe(sectionRef.current);
        }

        return () => observer.disconnect();
    }, []);

    return (
        <section ref={sectionRef} className={classes.section}>
            <div className={classes.content}>
                <div className={classes.contentImage}>
                    <img src={welcomeDoctor} alt="Doctor" />
                </div>
                <div className={classes.contentData}>
                    <h2 className={classes.title}>New Patients Welcome</h2>
                    <p className={classes.subtitle}>
                        We are dedicated to providing exceptional healthcare with compassion and expertise. Our experienced medical team is here to support you on your journey to better health. Schedule your appointment today and experience personalized care tailored to your needs.
                    </p>
                </div>
            </div>
        </section>
    );
}
