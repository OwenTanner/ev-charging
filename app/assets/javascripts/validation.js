document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('your-name-form');
    const fullNameInput = document.getElementById('full-name');
    const errorMessage = document.getElementById('error-message');
    const continueButton = document.getElementById('continue-button');

    continueButton.addEventListener('click', (event) => {
        // Hide error message by default
        errorMessage.hidden = true;

        // Check if the full name field is empty
        if (fullNameInput.value.trim() === '') {
            // Prevent form submission
            event.preventDefault();

            // Show error message
            errorMessage.hidden = false;

            // Focus on the input field
            fullNameInput.focus();
        } else {
            // Submit the form if validation passes
            form.submit();
        }
    });
});

