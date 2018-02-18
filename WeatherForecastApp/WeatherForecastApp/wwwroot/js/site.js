var app = new Vue({
    el: '#main',


    data: {
        weatherForecast: {},
        currentWeather: {},

        cityName: "",
        validCityName: true,
    },




    computed: {

        getCurrentTime: function () {
            var time = new Date();
            return time.getHours() + ":" + (time.getMinutes() < 10 ? "0" + time.getMinutes() : time.getMinutes());
        },


        


    },





    methods: {

        getWeatherForCity: function () {

            $.ajax({
                url: "/Home/GetWeatherForecast",
                data: {
                    city: this.cityName === "" ? "Kiev" : this.cityName,
                },
                method: "GET",
                success: function (data) {

                    if (data !== "") {
                        this.weatherForecast = JSON.parse(data);
                    }


                }.bind(this),


            });

            $.ajax({
                url: "/Home/GetCurrentWeather",
                data: {
                    city: this.cityName === "" ? "Kiev" : this.cityName,
                },
                method: "GET",
                success: function (data) {

                    if (data !== "") {
                        this.currentWeather = JSON.parse(data);

                        this.cityName = "";
                        this.validCityName = true;
                    }
                    else {
                        this.validCityName = false;
                    }


                }.bind(this),


            });

        },


        getCurrentDate: function () {
            var d = new Date();

            var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            var monthes = ["January", "February", "March", "April", "May", "June", "July", "April", "September", "October", "November", "December"];

            return days[d.getDay()] + " " + d.getDate() + " " + monthes[d.getMonth()];
        },

        getDate: function (date) {
            var day = date.substring(0, 2);
            var month = date.substring(5, 4);

            var monthes = ["January", "February", "March", "April", "May", "June", "July", "April", "September", "October", "November", "December"];
            
            return day + " " +  monthes[month - 1];
        }

    },





    mounted() {

        this.getWeatherForCity();

        $("#main").delay(200).animate({ opacity: 1 }, 1500);
    }
});



