console.log('submitForm.js loaded successfully');

document.addEventListener('DOMContentLoaded', () => {
    const submitButton = document.getElementById('submitButton');

    if (submitButton) {
        submitButton.addEventListener('click', async (e) => {
            e.preventDefault();
            console.log('Submit button clicked'); // Debugging line

            // Populate formData with sample data
            const formData = {
				addressLine1: "hardcode1",
				postcode: "hardcode2",
				fullName: "hardcode3",
				vehicleRegistrationNumber: "hardcode4",
				emailAddress: "hardcode5@outlook.com"
			};
			

            try {
                const response = await fetch('http://localhost:5051/application/submit-form', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(formData)
                });

                console.log(response.status);
                console.log(await response.text());

                if (response.ok) {
                    window.location.href = '/confirmation';
                } else {
                    console.error('Failed to submit the form');
                    alert('Error submitting the form.');
                }
            } catch (error) {
                console.error('Network error:', error);
                alert('Error submitting the form. Please try again later.');
            }
        });
    } else {
        console.error('Submit button not found');
    }
});
