import classes from '../Components/Reviews.module.css';
import photo from '../assets/image.jpg';

export default function Reviews({ data }) {

    const reviews = Array.isArray(data) ? data : [];

    return (
        <section className={classes.section}>
            <div className={classes.container}>
                <div className={classes.containerTitle}>
                    <h2 className={classes.title}>Patient Reviews</h2>
                    <h3 className={classes.subtitle}>Reviews from <span className={classes.highlight}> {reviews.length} </span>visitors</h3>
                </div>
                <div className={classes.containerDataShow}>

                    {reviews.length > 0 ? (
                        reviews.map((review) => (
                            <div key={review.reviewId} className={classes.containerData}>
                                <div className={classes.imagecontaner}>
                                    <img src={photo} alt={photo} />
                                </div>
                                <div className={classes.Datacontaner}>
                                    <h3>{review.userName}</h3>
                                    <div className={classes.rating}>
                                        {Array.from({ length: 5 }, (_, i) => (
                                            <i
                                                key={i}
                                                className={i < Math.round(review.rating) ? "fas fa-star" : "far fa-star"}>
                                            </i>
                                        ))}
                                    </div>
                                    <p>{review.comment}</p>
                                </div>
                            </div>
                        ))
                    ) : (
                        <p className={classes.noReviews}>No reviews available.</p>
                    )}
                </div>
            </div>
        </section>
    );
}
