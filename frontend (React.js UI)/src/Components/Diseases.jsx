import classes from '../Components/Diseases.module.css';

const diseaseImages = {
    "Influenza": "https://persadahospital.co.id/adminweb/assets/foto_article_web/030624110901_Penyebab_Penyaki.jpg",
    "Diabetes": "https://f.hubspotusercontent30.net/hubfs/2027031/diabetes.jpeg",
    "Hypertension": "https://www.fastmed.com/wp-content/uploads/blood_pressure-1200x800.jpg",
    "Asthma": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEyZgmooF1rkfjtd24L06Q6eSMG5hi_EH8TQ&s",
    "Migraine": "https://sa1s3optim.patientpop.com/assets/images/provider/photos/2263539.jpg",
    "COVID-19": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5c8qTfL3AJWgcdjLX6fmLy52GweaioJDaXA&s"
};


export default function Diseases({ data }) {

    if (!data || data.length === 0) {
        return (
            <section className={classes.section}>
                <h2 className={classes.title}>Diseases We Treat</h2>
                <h3>Loading...</h3>
                <div className={classes.loader}></div>
            </section>
        );
    }

    return (
        <section className={classes.section}>
            <h2 className={classes.title}>Diseases We Treat</h2>
            <div className={classes.diseasesContainer}>
                {data.map(disease => (
                    <div key={disease.diseaseId} className={classes.diseaseCard}>
                        <img
                            src={diseaseImages[disease.name] || "https://via.placeholder.com/250x300"}
                            alt={disease.name}
                            className={classes.diseaseImage}
                        />
                        <div className={classes.diseaseInfo}>
                            <h2 className={classes.diseaseName}>{disease.name}</h2>
                            <ul className={classes.symptomList}>
                                {disease.symptom.map(sym => (
                                    <li key={sym.symptomId} className={classes.symptomItem}>{sym.name}</li>
                                ))}
                            </ul>
                        </div>
                    </div>
                ))}
            </div>
        </section>

    );
}
