export async function loader({ params }) {

    const nurseId = params.nurseId;

    try {

        const nurseResponse = await fetch(`https://carefirst-v1.runasp.net/api/Nurses/${nurseId}`)


        if (!nurseResponse.ok) throw new Error("Failed to fetch doctor data");

        const nurseData = await nurseResponse.json();

        return { nurseData };

    } catch (error) {
        console.error("Error loading data:", error);
        return { doctorData: null };
    }
}
