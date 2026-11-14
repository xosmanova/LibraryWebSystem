// Library Management System JavaScript
$(document).ready(function () {
    // Sidebar toggle for mobile
    $('#sidebarToggle').on('click', function () {
        $('.sidebar').toggleClass('show');
    });

    // Handle AJAX toggle switch for Book Status in Index view (Image 2)
    $('.status-switch').on('change', function () {
        var checkbox = $(this);
        var bookId = checkbox.data('book-id');

        $.ajax({
            url: '/Books/ToggleStatus',
            type: 'POST',
            data: { id: bookId },
            success: function (response) {
                if (response.success) {
                    var label = $('#status-label-' + bookId);
                    if (response.isActive) {
                        label.text('Active').removeClass('text-muted').addClass('text-success');
                    } else {
                        label.text('Inactive').removeClass('text-success').addClass('text-muted');
                    }
                }
            },
            error: function () {
                alert('Error updating book status.');
                // Revert switch state
                checkbox.prop('checked', !checkbox.prop('checked'));
            }
        });
    });
});
