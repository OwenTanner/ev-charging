console.log('submitForm.js loaded successfully');


document.addEventListener('DOMContentLoaded', () => {
    const submitButton = document.getElementById('submitButton');

    if (submitButton) {
        submitButton.addEventListener('click', async (e) => {
            e.preventDefault();
            console.log('Submit button clicked'); // Debugging line

            //Form submission logic
            const formData = { /* your data */ };
            const response = await fetch('/application/submit-form', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                window.location.href = '/confirmation';
            } else {
                console.error('Failed to submit the form');
                alert('Error submitting the form.');
            }
        });
    } else {
        console.error('Submit button not found');
    }
});
