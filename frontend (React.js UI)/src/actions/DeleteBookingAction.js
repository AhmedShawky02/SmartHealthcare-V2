export async function action({ request }) {
    const formData = await request.formData();

    const bookingId = await formData.get("id")

    try {

        const response = await fetch(`https://carefirst-v1.runasp.net/api/Booking/${bookingId}`, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
        });

        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }

        if (!response.ok) {
            return { message: responseData.message || responseData || "Booking deleted failed ❌" };
        }

        return { message: responseData.message|| responseData || "Booking deleted successfully ✅" };

    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }

}