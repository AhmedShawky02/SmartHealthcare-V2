export async function loader({ params }) {

    const doctorId = params.doctorId;

    try {

        const [doctorResponse, reviewsResponse] = await Promise.all([
            fetch(`https://carefirst-v1.runasp.net/api/Doctors/${doctorId}`),
            fetch(`https://carefirst-v1.runasp.net/api/Reviews/reviews/${doctorId}`)
        ]);

        if (!doctorResponse.ok) throw new Error("Failed to fetch doctor data");

        const doctorData = await doctorResponse.json();

        let reviewsData = [];
        if (reviewsResponse.ok) {
            reviewsData = await reviewsResponse.json();
        } else {
            console.warn("Reviews not found or error occurred, returning empty array.");
        }

        return { doctorData, reviewsData };

    } catch (error) {
        console.error("Error loading data:", error);
        return { doctorData: null, reviewsData: [] };
    }
}
