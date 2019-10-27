function CreatePIE(Used, Max) {
    $(document).ready(function () {
        var pie = new d3pie("pie", {

            data: {
                content: [
                  { label: "فضای پر شده", value: Used },
                  { label: "فضای خالی", value: Max }
                ]
            }
        });
    });
}