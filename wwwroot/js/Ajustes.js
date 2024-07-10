
    document.addEventListener('DOMContentLoaded', () => {
        const darkModeToggle = document.getElementById('dark-mode-toggle');
    const darkModeStylesheet = document.getElementById('dark-mode-stylesheet');

    // Check local storage for the dark mode preference
    if (localStorage.getItem('dark-mode') === 'enabled') {
        document.body.classList.add('dark-mode');
    darkModeStylesheet.removeAttribute('disabled');
        } else {
        document.body.classList.remove('dark-mode');
    darkModeStylesheet.setAttribute('disabled', 'true');
        }

        // Toggle dark mode on button click
        darkModeToggle.addEventListener('click', () => {
            if (document.body.classList.contains('dark-mode')) {
        document.body.classList.remove('dark-mode');
    darkModeStylesheet.setAttribute('disabled', 'true');
    localStorage.setItem('dark-mode', 'disabled');
            } else {
        document.body.classList.add('dark-mode');
    darkModeStylesheet.removeAttribute('disabled');
    localStorage.setItem('dark-mode', 'enabled');
            }
        });
    });
