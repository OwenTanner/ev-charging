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

document.addEventListener('DOMContentLoaded', () => {
    const vrnForm = document.getElementById('vrnForm'); // The form for VRN
    const vrnInput = document.getElementById('vehicleRegistrationNumber'); // The VRN input field
    const errorMessage = document.getElementById('vehicleRegistrationNumber-error'); // Inline error
    const errorSummary = document.getElementById('error-message'); // Summary error
    const vrnContainer = document.getElementById('vehicleRegistrationNumber-container'); // Input container

    if (vrnForm) {
        vrnForm.addEventListener('submit', (event) => {
            console.log('VRN form submit button clicked'); // Debugging log
            let isValid = true;

            // Reset previous errors
            errorMessage.style.display = 'none';
            errorSummary.hidden = true;
            vrnContainer.classList.remove('govuk-form-group--error');

            // Validate the VRN input field
            if (vrnInput.value.trim() === '') {
                console.log('VRN field is empty'); // Debugging log
                isValid = false;

                // Show inline error message
                errorMessage.style.display = 'block';
                errorMessage.textContent = 'Enter your vehicle registration number';

                // Highlight the field with an error
                vrnContainer.classList.add('govuk-form-group--error');

                // Show error summary
                errorSummary.hidden = false;
            }

            // Prevent form submission if invalid
            if (!isValid) {
                event.preventDefault(); // Prevent navigation
                vrnInput.focus(); // Focus on the VRN field
                console.log('Form submission prevented due to validation errors'); // Debugging log
            } else {
                console.log('Form is valid, proceeding to the next page'); // Debugging log
            }
        });
    } else {
        console.error('VRN form not found'); // Debugging log
    }
});


