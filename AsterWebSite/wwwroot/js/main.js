document.addEventListener("DOMContentLoaded", () => {
    const header = document.getElementById("main-header");
    const headerHeight = header.offsetHeight;

    let lastScrollY = window.scrollY;

    window.addEventListener("scroll", () => {
        const currentScrollY = window.scrollY;

        // Only show sticky header when scrolling up
        if (currentScrollY < lastScrollY && currentScrollY > headerHeight) {
            header.classList.add("header-sticky");
        } else {
            header.classList.remove("header-sticky");
        }

        // Update lastScrollY to the current position
        lastScrollY = currentScrollY;
    });
});
