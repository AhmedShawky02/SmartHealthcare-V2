export async function action({ request, params }) {
    const formData = await request.formData();

    const date = formData.get("date");
    const username = formData.get("username");
    const nurseId = params.nurseId;


    if (!date || !username || !nurseId) {
        return { message: "Invalid input data. Please fill all fields ❌" };
    }

    const bookingData = {
        date: new Date(date).toISOString(),
        userName: username,
        nurseId: Number(nurseId)
    };
    

    console.log("Sending booking data:", bookingData);

    try {

        const response = await fetch("https://carefirst-v1.runasp.net/api/Booking/CreateBookingForNurse", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(bookingData)
        });


        const contentType = response.headers.get("content-type");
        let responseData;

        if (contentType && contentType.includes("application/json")) {
            responseData = await response.json();
        } else {
            responseData = await response.text();
        }

        // console.log("contentType:", contentType);
        // console.log("responseData:", responseData);
        // console.log("responseData message:", responseData.message);

        if (!response.ok) {
            return { message: responseData.message || responseData || "Booking failed ❌" };
        }

        return { message: responseData.message || "Booking successfully! ✅" };

        
    } catch (error) {
        return { message: `Something went wrong: ${error.message} ❌` };
    }
}
