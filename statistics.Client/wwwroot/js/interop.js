let chart;

function createChart() {
	setTimeout(() => {
			const ctx = document.getElementById("chart").getContext("2d");
			chart = new Chart(ctx,
				{
					// The type of chart we want to create
					type: 'line',

					// The data for our dataset
					data: {
						labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
						datasets: [
							{
								backgroundColor: 'rgb(255, 99, 132)',
								borderColor: 'rgb(255, 150, 132)',
								data: [0, 10, 5, 2, 20, 30, 45],
							}
						]
					},
					// Configuration options go here
					options: {
						legend: {
							display: false
						},
						scales: {
							xAxes: [
								{
									gridLines: {
										display: true,
										color: "#fff",
									},
									ticks: {
										fontColor: "#fff",
									},
								}
							],
							yAxes: [
								{
									ticks: {
										fontColor: "#fff",
									},
									display: true,
									gridLines: {
										display: true,
										color: "#fff",
									},
								}
							],
						}
					},
					responsive: true
				});
		},
		1000);
}