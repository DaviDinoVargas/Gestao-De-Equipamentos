document.addEventListener('DOMContentLoaded', function () {
    const dropdownToggles = document.querySelectorAll('.dropdown-toggle');
    console.log('dropdownToggles:', dropdownToggles); 

    dropdownToggles.forEach(toggle => {
        toggle.addEventListener('click', function (e) {
            console.log('Toggle clicado');
            e.preventDefault();
            const parentItem = this.closest('.has-dropdown');

            document.querySelectorAll('.has-dropdown').forEach(item => {
                if (item !== parentItem) {
                    item.classList.remove('active');
                }
            });

            if (parentItem) {
                parentItem.classList.toggle('active');
            }
        });
    });

    document.addEventListener('click', function (e) {
        if (!e.target.closest('.has-dropdown')) {
            document.querySelectorAll('.has-dropdown').forEach(item => {
                item.classList.remove('active');
            });
        }
    });
});