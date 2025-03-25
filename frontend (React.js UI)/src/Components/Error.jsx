import classes from '../Components/Error.module.css';

export default function Error() {
    return (
        <>
            <main className={classes.main}>
                <h1 className={classes.title}>404 - Page Not Found</h1>
                <p className={classes.subTitle}>Oops! The page you are looking for does not exist.</p>
            </main>
        </>
    );
}