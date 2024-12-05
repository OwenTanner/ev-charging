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


document.addEventListener('DOMContentLoaded', () => {
    const emailForm = document.getElementById('emailForm');
    const emailInput = document.getElementById('email');

    if (emailForm) {
        emailForm.addEventListener('submit', (event) => {
            let isValid = true;

            // Clear previous errors
            const errorMessage = document.getElementById('email-error');
            const errorSummary = document.getElementById('error-message');
            const emailContainer = document.getElementById('email-container');

            errorMessage.style.display = 'none';
            errorSummary.hidden = true;
            emailContainer.classList.remove('govuk-form-group--error');

            // Validate the email input
            if (emailInput.value.trim() === '') {
                isValid = false;

                // Show inline error message
                errorMessage.style.display = 'block';
                errorMessage.textContent = 'Enter your email address';

                // Highlight the field with an error
                emailContainer.classList.add('govuk-form-group--error');

                // Show error summary
                errorSummary.hidden = false;
            }

            // Prevent form submission if invalid
            if (!isValid) {
                event.preventDefault();
                emailInput.focus();
            }
        });
    }
});

