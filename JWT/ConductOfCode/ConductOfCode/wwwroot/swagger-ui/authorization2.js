(function () {
    $(function () {
        var tokenUi = '<div class="input">' +
            '<h2>Authenticate</h2>' +
            '<input placeholder="Audience" id="input_audience" name="audience" type="text" size="50">' +
            '<input placeholder="Issuer" id="input_issuer" name="issuer" type="text" size="50">' +
            '<input placeholder="Signing key" id="input_signing_key" name="signing_key" type="text" size="100">' +
            '</div>';
        $(tokenUi).insertBefore("#resources_container");

        $(".submit").click(function () {
            var audience = $("#input_audience").val();
            var issuer = $("#input_issuer").val();
            var signingKey = $("#input_signing_key").val();
            var token = generateToken(audience, issuer, signingKey);

            addAuthorization("Bearer " + token);
        });
    });
    function generateToken(audience, issuer, signingKey) {
        var exp = Date.now() / 1000 | 0;

        var header = { 'alg': 'HS256', 'typ': 'JWT' };
        var payload = { 'aud': audience, 'iss': issuer, 'exp': exp };

        var unsignedToken = base64Object(header) + "." + base64Object(payload);

        var signature = CryptoJS.HmacSHA256(unsignedToken, signingKey).toString(CryptoJS.enc.Base64);
        var token = unsignedToken + "." + signature;

        return removeIllegalCharacters(token);
    };
    function base64Object(input) {
        var inputWords = CryptoJS.enc.Utf8.parse(JSON.stringify(input));
        var base64 = CryptoJS.enc.Base64.stringify(inputWords);
        var output = removeIllegalCharacters(base64);
        return output;
    };
    function removeIllegalCharacters(input) {
        return input
            .replace(/=/g, '')
            .replace(/\+/g, '-')
            .replace(/\//g, '_');
    };
    function addAuthorization(key) {
        window.swaggerUi.api.clientAuthorizations.add("key", new SwaggerClient.ApiKeyAuthorization("Authorization", key, "header"));
    };
})();