//// ✅ Floating Alert Function
//function showFloatingAlert(message, type = "warning", duration = 3000) {
//    const alert = $("#floatingAlert");
//    const msg = $("#floatingAlertMessage");

//    alert
//        .removeClass("d-none alert-warning alert-success alert-danger alert-info show")
//        .addClass(`alert-${type} fade`);
//    msg.html(message);

//    // Trigger fade-in
//    setTimeout(() => alert.addClass("show"), 10);

//    // Auto-dismiss after duration
//    setTimeout(() => {
//        alert.removeClass("show");
//        setTimeout(() => alert.addClass("d-none"), 300); // match fade duration
//    }, duration);
//}
