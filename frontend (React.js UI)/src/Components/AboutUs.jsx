import React from "react";
import classes from '../Components/AboutUs.module.css';

const AboutUs = () => {
  return (
    <>
      <section className={classes.section}>
        <div className={classes.container}>
          <h1 className={classes.title}>About Us – Smart Healthcare System</h1>
          <p className={classes.subtitle}>
            Welcome to Smart Healthcare System, your all-in-one platform for seamless and efficient healthcare services. Our mission is to revolutionize the way patients, doctors, and medical centers interact by providing a smart, secure, and user-friendly system that enhances accessibility and convenience.
          </p>

          <h2 className={classes.sectionTitle}>Our Mission</h2>
          <p className={classes.text}>
            We strive to improve healthcare quality through technology by offering an advanced digital system that allows users to access medical services effortlessly. Whether you're a patient seeking consultation, a doctor managing appointments, or a medical center organizing its data, our platform ensures a smooth and hassle-free experience.
          </p>

          <h2 className={classes.sectionTitle}>What We Offer</h2>
          <ul className={classes.list}>
            <li><strong>Book Doctors & Nurses:</strong> Find and schedule appointments easily.</li>
            <li><strong>Manage Appointments:</strong> Modify or cancel with a click.</li>
            <li><strong>Medical Centers Directory:</strong> Access detailed info on top centers.</li>
            <li><strong>Health Resources:</strong> Learn from expert videos & articles.</li>
            <li><strong>Secure & Reliable:</strong> Your data is fully protected.</li>
          </ul>

          <h2 className={classes.sectionTitle}>Why Choose Us?</h2>
          <ul className={classes.list}>
            <li><strong>Convenience:</strong> Access healthcare services anytime, anywhere.</li>
            <li><strong>Time-Saving:</strong> No more long queues – book appointments in minutes.</li>
            <li><strong>Secure:</strong> Your privacy is our priority.</li>
            <li><strong>Comprehensive Healthcare Access:</strong> Everything you need, in one place.</li>
          </ul>

          <p className={classes.footerText}>At Smart Healthcare System, we believe in making healthcare simple, accessible, and efficient. Join us today and experience the future of digital healthcare!</p>
          <p className={classes.contact}>📩 Contact us: <a href="mailto:contact@medicalcenter.com">contact@medicalcenter.com</a></p>
        </div>
      </section>
    </>
  );
};

export default AboutUs;
