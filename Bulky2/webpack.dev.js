var path = require('path');
const ESLintPlugin = require('eslint-webpack-plugin');
const StylelintPlugin = require('stylelint-webpack-plugin');

module.exports = {
    plugins: [
        new StylelintPlugin({
            files: "Resources/Styles/**/*.{css,sass,scss,sss,less}",
        }),
        new ESLintPlugin()
    ],
    entry: {
        main: './Resources/Scripts/main'
    },
    output: {
        publicPath: '/js/',
        path: path.join(__dirname, '/wwwroot/js/'),
        filename: 'main.build.js'
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    "style-loader",
                    "css-loader",
                    {
                        loader: "sass-loader",
                        options: {
                            sourceMap: true
                        }
                    }
                ]
            }

        ]
    },
    mode: "development"
};