console.log('submitForm.js loaded successfully');

document.addEventListener('DOMContentLoaded', () => {
    const submitButton = document.getElementById('submitButton');

    if (submitButton) {
        submitButton.addEventListener('click', async (e) => {
            e.preventDefault();
            console.log('Submit button clicked'); // Debugging line

            // Populate formData with sample data
            const formData = {
				addressLine1: document.getElementById('addressLine1').value,
				postcode: document.getElementById('postcode').value,
				fullName: document.getElementById('fullName').value,
				vehicleRegistrationNumber: document.getElementById('vehicleRegistrationNumber').value,
				emailAddress: document.getElementById('emailAddress').value
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
