$(function () {
    $('.lbtndefault').on('click', function () {

        var x = $(this);

        alertify.set({ labels: {
            ok: "Si",
            cancel: "No"
        }
        });
        alertify.confirm(x.data('msg'), function (e) {
            if (e) {
                location.href = x.data('url');
            } else {
                alertify.error(x.data('cancel'));
            }
        });
        return false;
    });
});