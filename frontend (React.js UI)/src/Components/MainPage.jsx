import { useEffect, useRef } from 'react';
import Doctor from '../assets/DoctorImage.png'
import classess from '../Components/MainPage.module.css'

export default function HomePage() {

    const sectionRef = useRef(null);

    useEffect(() => {
        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    sectionRef.current.querySelector(`.${classess.contentImage}`).classList.add(classess.visible);
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
        <>
            <section ref={sectionRef} className={classess.section}>
                <div className={classess.content}>
                    <div className={classess.contentData}>
                        <h1 className={classess.title}>Med Center Healthcare</h1>
                        <h2 className={classess.subtitle}>Enhancing Lives</h2>
                        <p className={classess.paragraph}>Med Center Healthcare brings you closer to advanced medical care with more locations, more innovation, and more lives transformed</p>
                    </div>
                    <div className={classess.contentImage}>
                        <img src={Doctor} alt={Doctor} />
                    </div>
                </div>
            </section>
        </>
    );
}