var authorize = function () {
    var audience = postman.getEnvironmentVariable("Audience");
    var issuer = postman.getEnvironmentVariable("Issuer");
    var signingKey = postman.getEnvironmentVariable("SigningKey");

    var token = generateToken(audience, issuer, signingKey);

    addAuthorization("Bearer " + token);
};
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
function addAuthorization(value) {
    postman.setGlobalVariable('Authorization', value);
};