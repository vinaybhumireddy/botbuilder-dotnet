﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;

namespace Microsoft.Bot.Builder.Dialogs
{
    public class InputRecognizer 
    {
        /// <summary>
        /// Gets or sets id of the recognizer.
        /// </summary>
        /// <value>Id.</value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Runs current DialogContext.TurnContext.Activity through a recognizer and returns a generic recognizer result.
        /// </summary>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual Task<RecognizerResult> RecognizeAsync(DialogContext dialogContext, CancellationToken cancellationToken = default)
        {
            return RecognizeAsync(dialogContext, dialogContext.Context.Activity, cancellationToken);
        }

        /// <summary>
        /// Runs current DialogContext.TurnContext.Activity through a recognizer and returns a strongly-typed recognizer result using IRecognizerConvert.
        /// </summary>
        /// <typeparam name="T">The recognition result type.</typeparam>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual async Task<T> RecognizeAsync<T>(DialogContext dialogContext, CancellationToken cancellationToken = default)
            where T : IRecognizerConvert, new()
        {
            var result = new T();
            result.Convert(await this.RecognizeAsync(dialogContext, cancellationToken).ConfigureAwait(false));
            return result;
        }

        /// <summary>
        /// Runs current DialogContext.TurnContext.Activity through a recognizer and returns a generic recognizer result.
        /// </summary>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="activity">activity to recognize.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual async Task<RecognizerResult> RecognizeAsync(DialogContext dialogContext, Activity activity, CancellationToken cancellationToken = default)
        {
            if (activity?.Type == ActivityTypes.Message)
            {
                return await this.RecognizeAsync(dialogContext, activity.Text, activity.Locale, cancellationToken).ConfigureAwait(false);
            }

            return new RecognizerResult();
        }

        /// <summary>
        /// Runs current DialogContext.TurnContext.Activity through a recognizer and returns a strongly-typed recognizer result using IRecognizerConvert.
        /// </summary>
        /// <typeparam name="T">The recognition result type.</typeparam>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="activity">activity to recognize.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual async Task<T> RecognizeAsync<T>(DialogContext dialogContext, Activity activity, CancellationToken cancellationToken = default)
            where T : IRecognizerConvert, new()
        {
            var result = new T();
            result.Convert(await this.RecognizeAsync(dialogContext, activity, cancellationToken).ConfigureAwait(false));
            return result;
        }

        /// <summary>
        /// Runs an utterance through an input recognizer and returns a generic recognizer result.
        /// </summary>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="text">text to recognize.</param>
        /// <param name="locale">locale to use for recognition.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual Task<RecognizerResult> RecognizeAsync(DialogContext dialogContext, string text, string locale, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("This recognizer doesn't implement a recognizer for pure text/locale input.");
        }

        /// <summary>
        /// Runs an utterance through a recognizer and returns a strongly-typed recognizer result using IRecognizerConvert.
        /// </summary>
        /// <typeparam name="T">The recognition result type.</typeparam>
        /// <param name="dialogContext">Dialog context.</param>
        /// <param name="text">text to recognize.</param>
        /// <param name="locale">locale to use for recognition.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Analysis of utterance.</returns>
        public virtual async Task<T> RecognizeAsync<T>(DialogContext dialogContext, string text, string locale, CancellationToken cancellationToken = default)
            where T : IRecognizerConvert, new()
        {
            var result = new T();
            result.Convert(await this.RecognizeAsync(dialogContext, text, locale, cancellationToken).ConfigureAwait(false));
            return result;
        }
    }
}
