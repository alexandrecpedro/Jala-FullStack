const path = require('path')
const webpack = require('webpack')

module.exports = {
    entry: './src/index.js',
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules)/,
                use: {
                    loader: 'babel-loader',
                }
            },
            {
                test: /\.css$/,
                use: [ "style-loader", "css-loader" ]
            }

        ]
    },
    resolve: { extensions: [ '.*', '.js', '.jsx' ] },
    output: {
        path: path.resolve(__dirname, 'dist/'),
        publicPath: '/dist/',
        filename: 'bundle.js'
    },
    devServer: {
        contentBase: path.join(__dirname, 'public/'),
        port: 2500,
        publicPath: 'http://localhost:2500/dist/',
        hotOnly: true
    },
    plugins: [ new webpack.HotModuleReplacementPlugin() ]
}