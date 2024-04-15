// Helper function
function prevPage() {
    window.history.back();
}
function nextPage() {
    window.history.forward()
}
function initChartSoLuongKhach(listVeTourJson) {
    var data = JSON.parse(listVeTourJson);

    // X? lý d? li?u ?? l?y ra s? l??ng khách và ngày ??t tour
    var labels = data.map(x => new Date(x.NgayDatTour).toLocaleDateString());
    var values = data.map(x => x.SoLuongKhach);

    var ctx = document.getElementById('chartSoLuongKhach').getContext('2d');
    var chartSoLuongKhach = new Chart(ctx, {
        type: 'line', // S? d?ng bi?u ?? ???ng
        data: {
            labels: labels,
            datasets: [{
                label: 'S? l??ng khách',
                data: values,
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}
